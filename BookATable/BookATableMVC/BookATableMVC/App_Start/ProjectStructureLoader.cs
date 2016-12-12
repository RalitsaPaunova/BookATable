using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using DAL.Repositories;
using DAL.Entites;
using System.Web.Mvc;

namespace BookATableMVC.App_Start
{
    public class ProjectStructureLoader
    {
        public static void Load()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var assembly = Assembly.GetExecutingAssembly();
                var authControllerRepo = new AuthControllerRepository(uow);
                var authActionRepo = new AuthActionRepository(uow);

                var controllersInAssembly = new List<AuthController>();

                foreach (Type T in assembly.GetTypes())
                {
                    if (typeof(Controller).IsAssignableFrom(T) && !T.IsGenericType && !T.IsAbstract)
                    {
                        AuthController controller = new AuthController();
                        controller.Name = T.Name;
                        controller.AuthActions = T.GetMethods().Where(m => typeof(ActionResult).IsAssignableFrom(m.ReturnType)).Select(
                            m => new AuthAction { AuthController = controller, Name = m.Name, MethodType = m.GetCustomAttribute<HttpPostAttribute>() == null ? AuthAction.Method.GET : AuthAction.Method.POST }).ToList();

                        controllersInAssembly.Add(controller);
                    }
                }

                var controllersInDb = authControllerRepo.GetAll();

                foreach (AuthController controller in controllersInDb)
                {
                    var controllerInAssembly = controllersInAssembly.FirstOrDefault(c => c.Name == controller.Name);

                    if (controllersInAssembly == null)
                    {
                        while (controller.AuthActions.Count > 0)
                        {
                            authActionRepo.Delete(controller.AuthActions.First());
                        }

                        authControllerRepo.Delete(controller);
                        continue;

                    }

                    List<AuthAction> actionsToDelete = new List<AuthAction>();
                    List<AuthAction> actionsToUpdate = new List<AuthAction>();

                    foreach (AuthAction action in controller.AuthActions)
                    {
                        AuthAction actionInAssembly = controllerInAssembly.AuthActions.FirstOrDefault(a => a.Name == action.Name);
                        if (actionInAssembly == null)
                        {
                            actionsToDelete.Add(action);
                            continue;
                        }
                        if (actionInAssembly.MethodType == action.MethodType)
                        {
                            controllerInAssembly.AuthActions.Remove(actionInAssembly);
                            continue;
                        }
                        else
                        {
                            action.MethodType = actionInAssembly.MethodType;
                            actionsToUpdate.Add(action);

                            controllerInAssembly.AuthActions.Remove(actionInAssembly);
                        }
                    }

                    actionsToDelete.ForEach(a => authActionRepo.Delete(a));
                    actionsToDelete.ForEach(a => authActionRepo.Save(a));

                    foreach (var newAction in controllerInAssembly.AuthActions)
                    {
                        newAction.AuthController = controller;

                        authActionRepo.Save(newAction);
                    }
                    controllersInAssembly.Remove(controllerInAssembly);

                }
                controllersInAssembly.ForEach(c => authControllerRepo.Save(c));
            }
        }
    }
}

