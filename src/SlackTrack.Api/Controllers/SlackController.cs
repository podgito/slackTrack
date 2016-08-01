using SlackTrack.Commands;
using SlackTrack.Dal.Models;
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


            var context = new SlackTrack.Dal.TaskDBContext();

            context.Users.Add(new Dal.Models.SlackUser { Id = "123abc", Name = "Padraic", TeamId = "test" });

            context.Teams.Add(new SlackTeam { Id = "test", Name = "testTeam" });

            context.SaveChanges();

            var action = new TaskLogItemCommandAction();

            var response = action.Action(command);

            return Ok(response);
        }


    }
}
