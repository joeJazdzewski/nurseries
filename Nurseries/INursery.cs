using System;
using System.Threading.Tasks;

namespace Nurseries
{
    public interface INursery : IDisposable
    {
        Task StartSoon(Action action);
    }
}
