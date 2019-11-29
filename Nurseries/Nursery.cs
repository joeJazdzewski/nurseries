using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Nurseries
{
    public class Nursery : INursery
    {
        private List<Task> tasks = new List<Task>();
        
        public void Dispose()
        {
            this.Dispose(true);
        }

        public Task StartSoon(Action action) 
        {
            
            var lastTask = tasks.LastOrDefault();
            if(lastTask != null)
                Task.WaitAll(lastTask);
                
            Task task = Task.Run(action);
            tasks.Add(task);
            return task;
        }

        protected void Dispose(bool disposing)
        {
            //Makes sure that we wait for all tasks
            Task waiting = Task.WhenAll(tasks);
            Task.WaitAll(waiting);
            if(waiting.Exception != null)
            {
                //throws any exceptions that the task come accross
                throw waiting.Exception;
            }
        }
    }
}
