using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUserManagement.Api.BusinessLogic
{
    public abstract class HandlerDecoratorBase<TIn, TOut> : IHandler<TIn, TOut>
    {
        protected HandlerDecoratorBase(IHandler<TIn, TOut> decorated)
        {
            Decorated = decorated;
        }
        public abstract TOut Handle(TIn input);

        protected IHandler<TIn, TOut> Decorated { get; }
    }
}