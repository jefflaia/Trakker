using System;
using System.Data;
using System.Web;
using System.Web.Mvc;

namespace Trakker.Helpers
{
    public class FormException : Exception
    {

        protected ModelStateDictionary _modelState;

        public string ErrorMessage
        {
            get
            {
                return base.Message.ToString();
            }
        }

        public FormException(string errorMessage)
            : base(errorMessage) { }

        public FormException(string errorMessage, Exception innerEx)
            : base(errorMessage, innerEx) { }


        public FormException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }

        public ModelStateDictionary ModelState
        {
            get
            {
                return _modelState;
            }

            set
            {
                _modelState = value;
            }
        }

    }
}