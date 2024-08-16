using LeokaEstetica.Platform.Models.Dto.Output.Pagination;

namespace LeokaEstetica.Platform.Models.Dto.Output.Project;

/// <summary>
/// Класс выходной модели пагинации проектов.
/// </summary>
public class CatalogPaginationProjectOutput
{
    public CatalogPaginationProjectOutput(int page, int pageSize, IEnumerable<CatalogProjectOutput> projects)
    {
        Page = page;
        Projects = projects;
        TotalNumberOfProjects = Projects.Select(cpo => cpo.TotalCount).FirstOrDefault();
        TotalNumberOfPages = (int)Math.Ceiling(TotalNumberOfProjects / (double)pageSize);
        
        // Если первая страница и записей менее максимального на странице,
        // то надо скрыть пагинацию, так как смысл в пагинации теряется в этом кейсе.
        // Применяем именно к 1 странице, к последней нет (там это надо показывать).
        if (page == 1 && Projects.Count() < pageSize)
            IsVisiblePagination = false;
        else
            IsVisiblePagination = true;
    }

    public void InitProjectsCollection()
    {
        
    }

    /// <summary>
    /// Номер страницы.
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// Список проектов для страницы.
    /// </summary>
    public IEnumerable<CatalogProjectOutput> Projects { get; }

    /// <summary>
    /// Общее кол-во проектов
    /// </summary>
    public int TotalNumberOfProjects { get; }

    /// <summary>
    /// Общее кол-во страниц
    /// </summary>
    public int TotalNumberOfPages { get; }

    /// <summary>
    /// Признак наличия предыдущей страницы.
    /// </summary>
    public bool HasPreviousPage => Page > 1;

    /// <summary>
    /// Признак наличия следующей страницы.
    /// </summary>
    public bool HasNextPage => Page < TotalNumberOfPages;
    
    /// <summary>
    /// Признак отображения пагинации.
    /// </summary>
    public bool IsVisiblePagination { get; }
    
}