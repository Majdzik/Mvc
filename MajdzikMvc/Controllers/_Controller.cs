using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace System.Web.Mvc
{
            using System.Xml.Serialization;
    /// <summary>
    /// Action result that serializes the specified object into XML and outputs it to the response stream.
    /// <example>
    /// <![CDATA[
    /// public XmlResult AsXml() {
    ///		List<Person> people = _peopleService.GetPeople();
    ///		return new XmlResult(people);
    /// }
    /// ]]>
    /// </example>
    /// </summary>
    public class XmlResult : ActionResult
    {
        private object _objectToSerialize;
        private XmlAttributeOverrides _xmlAttribueOverrides;

        /// <summary>
        /// Creates a new instance of the XmlResult class.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize to XML.</param>
        public XmlResult(object objectToSerialize)
        {
            _objectToSerialize = objectToSerialize;
        }

        /// <summary>
        /// Creates a new instance of the XMLResult class.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize to XML.</param>
        /// <param name="xmlAttributeOverrides"></param>
        public XmlResult(object objectToSerialize, XmlAttributeOverrides xmlAttributeOverrides)
        {
            _objectToSerialize = objectToSerialize;
            _xmlAttribueOverrides = xmlAttributeOverrides;
        }

        /// <summary>
        /// The object to be serialized to XML.
        /// </summary>
        public object ObjectToSerialize
        {
            get { return _objectToSerialize; }
        }

        /// <summary>
        /// Serialises the object that was passed into the constructor to XML and writes the corresponding XML to the result stream.
        /// </summary>
        /// <param name="context">The controller context for the current request.</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (_objectToSerialize != null)
            {
                var xs = (_xmlAttribueOverrides == null) ?
                    new XmlSerializer(_objectToSerialize.GetType()) :
                    new XmlSerializer(_objectToSerialize.GetType(), _xmlAttribueOverrides);
                context.HttpContext.Response.ContentType = "text/xml";
                xs.Serialize(context.HttpContext.Response.Output, _objectToSerialize);
            }
        }
    }
}

namespace MajdzikMvc.Controllers
{
    public class _Controller : Controller
    {

        public _Controller()
        {

        }


        protected new ActionResult PartialView(string viewName, object model)
        {
            switch (GetContentType().ToLower())
            {
                case "json":
                    return new JsonResult() { Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                    break;
                case "xml":
                    return new XmlResult(model);
                    break;
                default:
                    return base.PartialView(viewName, model);
                    break;


            }

            return base.PartialView(viewName, model);
        }

        protected virtual ActionResult  View(IView view, object model)
        {
            switch (GetContentType().ToLower())
            {
                case "json":
                    return new JsonResult() {Data = model, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
                    break;
                case "xml":
                    return new XmlResult(model);
                    break;
                default:
                    return base.View(view, model);
                    break;

                    
            }

            return base.View(view, model);
        }




        protected virtual string GetContentType()
        {
            var type = Request.QueryString["type"];
            return string.IsNullOrEmpty(type) ? Request.IsAjaxRequest() ? Request.Headers["Accept"].Contains("application/json") ? "json" : "xml" : "html" : type;
        }


        // GET: _
        //public ActionResult Index()
        //{
        //    if (Request.IsAjaxRequest())
        //        return PartialView("_partview");
        //    return View();
        //}

        // GET: _/Details/5
        public ViewResult Details(int id)
        {
            return View();
        }

        // GET: _/Create
        public ViewResult Create()
        {
            return View();
        }

        // POST: _/Create
        [HttpPost]
        public ViewResult Create(FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{

            //}        
            return View();
        }

        // GET: _/Edit/5
        public ViewResult Edit(int id)
        {
            return View();
        }

        // POST: _/Edit/5
        [HttpPost]
        public ViewResult Edit(int id, FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add update logic here
            //     return RedirectToAction("Index");

            //}
            //catch
            //{
            //   
            //}   
            return View();
        }

        // GET: _/Delete/5
        public ViewResult Delete(int id)
        {
            return View();
        }

        // POST: _/Delete/5
        [HttpPost]
        public ViewResult Delete(int id, FormCollection collection)
        {
            //try
            //{
            //    // TODO: Add delete logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{

            //}         
            return View();
        }
    }

   
}
