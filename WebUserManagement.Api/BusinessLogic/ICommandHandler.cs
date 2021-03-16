using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUserManagement.Api.BusinessLogic
{
    public interface ICommandHandler<in TIn, out TOut> : IHandler<TIn, TOut>
                                                         where TIn : ICommand<TOut>
    {
    }

    public interface ICommand<out TResult> { }
}
