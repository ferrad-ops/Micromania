using Micromania.Domain;
using Micromania.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Micromania.Presentation
{
    public partial class App : Application
    {
        public App()
        {
            Initer.Init("Server=DESKTOP-H9JQ47G;Database=Micromania;Trusted_Connection=True;");
        }
    }
}
