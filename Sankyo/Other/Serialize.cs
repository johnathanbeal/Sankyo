using Newtonsoft.Json;
using Sankyo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Sankyo.Entities.Tweentity;

namespace Sankyo.Other
{
    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Tweentity.Converter.Settings);
    }

}
