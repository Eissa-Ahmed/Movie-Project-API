using Microsoft.EntityFrameworkCore;
using Movie.DAL.Database;
using Movie.DAL.Entity;

namespace Movie.BL.Repository
{
    public class GenerRepo : IGener
    {
        #region Property
        private readonly IMapper mapper;
        private readonly ApplicationDbContext dbContext;
        #endregion

        #region Ctor
        public GenerRepo(ApplicationDbContext dbContext , IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<UpdateGenerDTO?> CreateGener(UpdateGenerDTO model)
        {
            if (model == null)
                return null;

            if (model.Name.Length > 20)
                return null;

            var item = mapper.Map<Gener>(model);
            await dbContext.Geners.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<GenersDTO?> DeleteGener(int id)
        {
            var item = await dbContext.Geners.SingleOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return null;
            dbContext.Geners.Remove(item);
            await dbContext.SaveChangesAsync();
            return mapper.Map<GenersDTO>(item);

        }

        public async Task<IEnumerable<GenersDTO>> GetAllGener()
        {
            var items = await dbContext.Geners.ToListAsync();
            var data = mapper.Map<IEnumerable<GenersDTO>>(items);
            return data;
        }

        public async Task<GenerMovieDTO> GetGenerAndMovieById(int id)
        {
            var item = await dbContext.Geners.Where(i => i.Id == id).Include(i => i.Movies).FirstOrDefaultAsync();
            if (item is null)
                throw new Exception("Id Is Not Exist");

            var data = mapper.Map<GenerMovieDTO>(item);
            return data;
        }

        public async Task<UpdateGenerDTO> UpdateGener(int id, UpdateGenerDTO model)
        {
            var item = await dbContext.Geners.FindAsync(id);
            if (item is null)
            {
                throw new Exception("ID Not Exist");
            }
            if (model is null)
            {
                throw new Exception("Data Is Empty");
            }
            item.Name = model.Name;
            await dbContext.SaveChangesAsync();
            return model;
        }
        #endregion

    }
}
