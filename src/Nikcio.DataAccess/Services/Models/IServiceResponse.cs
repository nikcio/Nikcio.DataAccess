using System.Net;

namespace Nikcio.DataAccess.Services.Models {
    /// <summary>
    /// A service response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceResponse<T> where T : class {
        /// <summary>
        /// The response value
        /// </summary>
        T ReponseValue { get; set; }

        /// <summary>
        /// The returned http status code
        /// </summary>
        HttpStatusCode StatusCode { get; set; }
    }
}
