using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletService.Models
{
    public class Push
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
    }
}
