﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace DebtMan.WebApp.MvcExtensibility
{
    internal class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return ObjectFactory.GetInstance(controllerType) as IController;
        }
    }
}
