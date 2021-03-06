﻿using ApplicationCore.Services;
using AutoMapper;
using Common.Utils;
using Extension.Extensions;
using Infrastructure.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Website.Configuaration;
using Website.ViewModel;

namespace Website.Areas.Admin.Controllers
{
    [CustomRoleAuthorize(Roles = "Admin")]
    public class ManagerActorsController : Controller
    {
        private readonly IActorsService _actorsService;

        private IList<ActorViewModel> _listActorViewModels;

        public ManagerActorsController(IActorsService actorsService)
        {
            _actorsService = actorsService;

            var actors = _actorsService.GetAll();
            if (actors != null)
            {
                var actorViewModels = Mapper.Map<IEnumerable<ActorViewModel>>(actors);

                _listActorViewModels = actorViewModels.ToList();
            }
        }

        public ActionResult Index(string name)
        {
            if (name == null)
            {
                Session["KeyWordSearch"] = null;
            }
            else
            {
                Session["KeyWordSearch"] = name;
            }
            if (_listActorViewModels == null)
            {
                return View();
            }
            return View(_listActorViewModels);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actor actor = _actorsService.Find(id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            ActorViewModel actorViewModel = Mapper.Map<ActorViewModel>(actor);
            return View(actorViewModel);
        }

        public ActionResult Create(Guid? id)
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(ActorViewModel actorViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                actorViewModel.Id = Guid.NewGuid();

                Actor actor = Mapper.Map<Actor>(actorViewModel);
                if (image != null)
                {
                    if (CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                    {
                        var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                        image.SaveAs(path);
                        actor.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                    }
                }
                _actorsService.Create(actor);

                return RedirectToAction("Index");
            }

            return PartialView("_Create", actorViewModel);
        }

        public ActionResult Edit(Guid id)
        {
            Actor actor = _actorsService.Find(id);

            ActorViewModel actorViewModel = Mapper.Map<ActorViewModel>(actor);

            return View("_Edit", actorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(ActorViewModel actorViewModel, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                Actor actor = Mapper.Map<Actor>(actorViewModel);
                if (image != null && 
                    image.FileName != null &&
                    CheckImageUploadExtension.CheckImagePath(image.FileName) == true)
                {
                    var path = Path.Combine(Server.MapPath("~/Images/Upload"), image.FileName);
                    image.SaveAs(path);
                    actor.Thumbnail = VariableUtils.UrlUpLoadImage + image.FileName;
                }
                _actorsService.Update(actor, actor.Id);
                return RedirectToAction("Index");
            }
            return View(actorViewModel);
        }

        public ActionResult Delete(Guid? id)
        {
            Actor actor = _actorsService.Find(id);

            ActorViewModel actorViewModel = Mapper.Map<ActorViewModel>(actor);
            return PartialView("_Delete", actorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            Actor actor = _actorsService.Find(id);

            if (actor == null)
            {
                return HttpNotFound();
            }

            _actorsService.Delete(actor);

            return RedirectToAction("Index");
        }
        
        public ActionResult GetPageSearch(int? page)
        {
            int pageSize = VariableUtils.pageSize;

            int pageNumber = (page ?? 1);

            if (Session["KeyWordSearch"] != null)
            {
                var name = Session["KeyWordSearch"].ToString();
                var listSearch = _actorsService.SearchActorByName(name);
                var listSearchModel = AutoMapper.Mapper.Map<IEnumerable<ActorViewModel>>(listSearch);
                return PartialView("_PartialViewActor", listSearchModel.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("_PartialViewActor", 
                _listActorViewModels.ToPagedList(pageNumber, pageSize));
        }
    }
}