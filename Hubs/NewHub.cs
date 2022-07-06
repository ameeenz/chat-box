using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ChatBox.Hubs
{
    public class NewHub:Hub
    {
        public void SendMessage(string Name,string Message)
        {
            Clients.All.SEND(Name, Message);
        }

        public void Watcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Amin\Downloads\Documents");
            watcher.EnableRaisingEvents = true;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Clients.All.ShowOperation(e.FullPath + " is created", "green");
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Clients.All.ShowOperation(e.FullPath + " is deleted", "red");
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Clients.All.ShowOperation(e.FullPath + " is modified", "yellow");
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Clients.All.ShowOperation(e.FullPath + " is renamed", "pink");

        }
   
    }
}