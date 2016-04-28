using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletService
{
    public interface IPushbulletService
    {
        void PbPush(string title, string message, string url, string apiKey);
    }
}
