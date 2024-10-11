using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Repository
{
    public interface IActionRepository<TModel, TFactory>
    {
        TimeSpan GetTime(TModel a);
        void Validate(TModel a);
        bool CanExecute(TModel a);
        bool Execute(TModel a);
        void Start(TModel a);
    }
}
