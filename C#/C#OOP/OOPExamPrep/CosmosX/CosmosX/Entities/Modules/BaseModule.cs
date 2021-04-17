using CosmosX.Entities.Modules.Contracts;
using System;

namespace CosmosX.Entities.Modules
{
    public abstract class BaseModule : IModule
    {
        protected BaseModule(int id)
        {
            this.Id = id;
        }

        public int Id { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} Module - {this.Id}" + Environment.NewLine;
        }
    }
}