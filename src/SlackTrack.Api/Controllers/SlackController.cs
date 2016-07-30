using SlackTrack.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SlackTrack.Api.Controllers
{
    public class SlackController : ApiController
    {

        public IHttpActionResult Post(SlackCommand command)
        {
            Trace.TraceInformation(command.Text);
            Trace.TraceInformation(command.User_name);
            Trace.TraceInformation(command.Channel_name);
            Trace.TraceInformation(command.Command);

            return Ok(new { text = "Got it!" });
        }


    }
}
