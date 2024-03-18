using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Idiomas.CRUD.Infraestructure.Context;
using Idiomas.CRUD.Application.ViewModel;
using AutoMapper;
using Idiomas.CRUD.Application.Dtos;
using Idiomas.CRUD.Application.Services;
using Idiomas.CRUD.Domain.CursoIdiomas.ValueObject;
using Microsoft.AspNetCore.Mvc.Rendering;
using Idiomas.CRUD.Domain.CursoIdiomas;

namespace Idiomas.CRUD.Web.Controllers
{
    public class AlunoWebController : Controller
    {
        private readonly IdiomasContext _context;
        private readonly IAlunoServices _alunoServices;
        private readonly IMapper _mapper;

        public AlunoWebController(IdiomasContext context, IAlunoServices alunoServices, IMapper mapper)
        {
            _context = context;
            _alunoServices = alunoServices;
            _mapper = mapper;
        }

        // GET: AlunoWeb
        public async Task<IActionResult> Index()
        {
            var alunos = await _context.Alunos.Include(x=>x.Turmas).ToListAsync();                        

            var result = _mapper.Map<List<AlunoViewModel>>(alunos);

            foreach (var alunoViewModel in result)
            {
                var aluno = alunos.FirstOrDefault(a => a.Id == alunoViewModel.Id);
                if (aluno != null)
                {
                    alunoViewModel.TurmasViewsModel = aluno.Turmas.Select(turma => new TurmaViewModel
                    {
                        TurmaId = turma.Id,
                        AnoLetivo = turma.AnoLetivo,
                        Numero = turma.Numero                        
                    }).ToList();
                }
            }

            return View(result);
        }

        // GET: AlunoWeb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.Include(x => x.Turmas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            var alunoViewModel = _mapper.Map<AlunoViewModel>(aluno);

            // Mapear as turmas para a lista de turmas na view model
            alunoViewModel.TurmasViewsModel = aluno.Turmas.Select(turma =>
                new TurmaViewModel
                {
                    TurmaId = turma.Id,
                    AnoLetivo = turma.AnoLetivo,
                    Numero = turma.Numero                   
                }).ToList();

            return View(alunoViewModel);
        }




       
        // GET: AlunoWeb/Create
        public async Task<IActionResult> Create()
        {
            var turmas = await _context.Turmas.ToListAsync();

            var alunoViewModel = new AlunoViewModel
            {
                TurmasViewsModel = turmas.Select(turma => new TurmaViewModel
                {
                    TurmaId = turma.Id,
                    AnoLetivo = turma.AnoLetivo,
                    Numero = turma.Numero
                }).ToList()
            };
            return View(alunoViewModel);
        }



        // POST: AlunoWeb/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel alunoViewModel)
        {
            try
            {
                // Criando um novo AlunoDto
                var alunoDto = new AlunoDto
                {
                    // Mapeando as propriedades com nomes idênticos
                    Id = alunoViewModel.Id,
                    Nome = alunoViewModel.Nome,
                    // Criando uma instância de Cpf com a string fornecida
                    Cpf = new Cpf(alunoViewModel.Cpf),
                    Email = new Email(alunoViewModel.Email),
                    TurmasDto = new List<TurmaDto>()
                };

                // Mapeando as turmas
                //alunoDto.TurmasDto = (ICollection<TurmaDto>?)alunoViewModel.TurmasViewsModel;

                // Mapeando as turmas
                foreach (var turmaViewModel in alunoViewModel.TurmasViewsModel)
                {
                    var turmaDto = new TurmaDto
                    {
                        // Mapeie os atributos da turma conforme necessário
                        Id = turmaViewModel.TurmaId,
                        AnoLetivo = turmaViewModel.AnoLetivo,
                        Numero = turmaViewModel.Numero
                    };

                    alunoDto.TurmasDto.Add(turmaDto);
                }


                // Chama o serviço para criar o aluno
                var aluno = await _alunoServices.CreateAsync(alunoDto);

                // Você pode fazer algo com o aluno retornado pelo serviço, se necessário

                return View(alunoViewModel);
            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro ao ModelState
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao criar o aluno: " + ex.Message);
                // Retorna a view com o ModelState atualizado
                return View(alunoViewModel);


            }

        }



        // GET: AlunoWeb/Edit/5
        public async Task<IActionResult> Edit(int? id, AlunoViewModel alunoViewModel)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var aluno = await _context.Alunos.FindAsync(id);
                if (aluno == null)
                {
                    return NotFound();
                }
                var alunoDto = new AlunoDto
                {
                    // Mapeando as propriedades com nomes idênticos
                    Id = alunoViewModel.Id,
                    Nome = alunoViewModel.Nome,
                    // Criando uma instância de Cpf com a string fornecida
                    Cpf = new Cpf(alunoViewModel.Cpf),
                    Email = new Email(alunoViewModel.Email)
                };

                // Mapeando as turmas
                alunoDto.TurmasDto = (ICollection<TurmaDto>?)alunoViewModel.TurmasViewsModel;

                // Chama o serviço para editar o aluno
                var alunoEdit = await _alunoServices.UpdateAsync(alunoDto);

                // Você pode fazer algo com o aluno retornado pelo serviço, se necessário

                return View(alunoViewModel);

            }
            catch (Exception ex)
            {
                // Adiciona uma mensagem de erro ao ModelState
                ModelState.AddModelError(string.Empty, "Ocorreu um erro ao editar o aluno: " + ex.Message);
                // Retorna a view com o ModelState atualizado
                return View(alunoViewModel);

            }

        }

        public async Task<IActionResult> Delete(int? id, AlunoViewModel alunoViewModel)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunoDto = new AlunoDto
            {
                // Mapeando as propriedades com nomes idênticos
                Id = alunoViewModel.Id,
                Nome = alunoViewModel.Nome,
                // Criando uma instância de Cpf com a string fornecida
                Cpf = new Cpf(alunoViewModel.Cpf),
                Email = new Email(alunoViewModel.Email)
            };

            // Mapeando as turmas
            alunoDto.TurmasDto = (ICollection<TurmaDto>?)alunoViewModel.TurmasViewsModel;

            // Chama o serviço para editar o aluno
            var alunoDelete = await _alunoServices.DeleteAsync(alunoDto.Id.Value);

            return View(alunoViewModel);
        }

        // POST: AlunoWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
