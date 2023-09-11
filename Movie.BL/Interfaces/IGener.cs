namespace Movie.BL.Interfaces
{
    public interface IGener
    {
        public Task<IEnumerable<GenersDTO>> GetAllGener();
        public Task<GenersDTO> DeleteGener(int id);
        public Task<UpdateGenerDTO> CreateGener(UpdateGenerDTO model);
        public Task<UpdateGenerDTO> UpdateGener(int id , UpdateGenerDTO model);
        public Task<GenerMovieDTO> GetGenerAndMovieById(int id);
    }
}
