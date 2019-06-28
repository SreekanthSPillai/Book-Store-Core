using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace PetStoreMvc.Models.ViewModel
{
    public class MenuItem
    {
        private Category _category;
        public Category Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (value != null)
                {
                    _category = value;
                    RouteValueDictionary = new RouteValueDictionary
                    {
                        { "CategoryId", value.Id }
                    };
                }
            }
        }
        public RouteValueDictionary RouteValueDictionary { get; private set; }
    }
}