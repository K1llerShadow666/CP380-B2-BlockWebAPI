using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;
using CP380_B2_BlockWebAPI.Models;

namespace CP380_B2_BlockWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PendingPayloadsController : ControllerBase
    {
        public List<PendingPayloads> payload;
        public PendingPayloads.BlocksPayload payloadList;

        public PendingPayloadsController(PendingPayloads.BlocksPayload payload)
        {
            this.payload = payload.blockPayload;
        }

        [HttpGet]
        public ActionResult<List<PendingPayloads>> Get()
        {
            return payload.ToList();
        }

        [HttpPost]
        public ActionResult<PendingPayloads> Post(PendingPayloads p)
        {
            var payloadTemp = payloadList.Add(p);
            return payloadTemp;
        }
    }
}
