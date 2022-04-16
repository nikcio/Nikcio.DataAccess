using System.Net;

namespace Nikcio.DataAccess.Services.Models {
    /// <inheritdoc/>
    public class ServiceResponse<T> : IServiceResponse<T> where T : class {
        /// <inheritdoc/>
        public ServiceResponse(HttpStatusCode statusCode, T? reponse) {
            StatusCode = statusCode;
            ResponseValue = reponse;
        }

        /// <inheritdoc/>
        public virtual HttpStatusCode StatusCode { get; set; }

        /// <inheritdoc/>
        public virtual T? ResponseValue { get; set; }
    }
}
