namespace Movie.BL.Interfaces
{
    public interface IGener
    {
        public Task<IEnumerable<GenerDTO>> GetAllGener();
        public Task<GenerDTO> DeleteGener(int id);
        public Task<UpdateGenerDTO> CreateGener(UpdateGenerDTO model);
        public Task<UpdateGenerDTO> UpdateGener(int id , UpdateGenerDTO model);
        public Task<GenerMovieDTO> GetGenerAndMovieById(int id);
    }
}
