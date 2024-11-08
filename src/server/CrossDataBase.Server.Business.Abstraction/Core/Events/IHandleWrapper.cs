using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDataBase.Server.Business.Abstraction.Core.Events;
public interface IHandleWrapper
{
    Task HandleAsync(object sender, ResponseEventData data, CancellationToken token);
    Task HandleAsync(object sender, StartEventData data, CancellationToken token);
}
