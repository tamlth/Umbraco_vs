using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace UmbracoMVC.ContentFinders
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class SetLastChanceContentFindersComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            //set the last chance content finder
            composition.SetContentLastChanceFinder<My404ContentFinder>();
        }
    }
}