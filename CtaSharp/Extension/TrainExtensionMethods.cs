using CtaSharp.EndPoint.DataSource;
using CtaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtaSharp.Extension
{
    public static class TrainExtensionMethods
    {
        public static void Refresh(this Train train)
        {
            IDataSource source = train.DataSource;
            source.ClearParameters();
            source.AddParameter("rt", train.ToString());



        }
    }
}
