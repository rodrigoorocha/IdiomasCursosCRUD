
namespace Idiomas.CRUD.Application.ViewModel
{
    public class AlunoViewModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public virtual ICollection<TurmaViewModel>? TurmasViewsModel { get; set; } = new List<TurmaViewModel>();
         


    }
}
