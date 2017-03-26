using Microsoft.AspNetCore.Mvc;
using SS.Entities;
using SS.Interfaces.Data;

namespace SS.WebUI.Controllers
{
    public abstract class DomainController<TEntity, TIRepository> : Controller
        where TIRepository: class, IRepository<TEntity>
        where TEntity: class, IEntity
    {

        #region [Fields]

        protected TIRepository _repository;

        #endregion

        #region [Constructors]

        public DomainController(TIRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region [Actions]

        public virtual IActionResult Index()
        {
            return View(_repository.All);
        }

        #endregion
    }
}