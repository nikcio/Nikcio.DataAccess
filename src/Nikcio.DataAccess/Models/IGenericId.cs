namespace Nikcio.DataAccess.Models {
    /// <summary>
    /// A model for declaring a generic id which can be used in generic methods and classes
    /// </summary>
    public interface IGenericId {

        /// <summary>
        /// Id
        /// </summary>
        int Id { get; set; }
    }
}
