using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Messages.UpdateExternalIdentities
{
    public class UpdateExternalIdentitiesMessage
    {
        public ExternalIdentities ExternalIdentities { get; set; }
    }
}
