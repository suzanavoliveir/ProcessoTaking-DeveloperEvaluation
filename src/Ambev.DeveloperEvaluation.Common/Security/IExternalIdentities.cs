namespace Ambev.DeveloperEvaluation.Common.Security
{
    /// <summary>
    /// Define o contrato para representação de um Identidades Externas no sistema.
    /// </summary>
    public interface IExternalIdentities
    {
        /// <summary>
        /// Obtém o identificador único do Identidades Externas.
        /// </summary>
        /// <returns>O ID do Identidades Externas como uma string.</returns>
        public string Id { get; }


    }
}
