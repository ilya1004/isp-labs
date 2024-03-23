using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BookManager.App;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        await unitOfWork.DeleteDatabaseAsync();
        await unitOfWork.CreateDatabaseAsync();

        await unitOfWork.AuthorsRepository.AddAsync(
            new Author(1, "Эрих Мария", "Ремарк", new DateTime(1898, 6, 22), new DateTime(1970, 9, 25)));
        await unitOfWork.AuthorsRepository.AddAsync(
            new Author(2, "Лев Николаевич", "Толстой", new DateTime(1828, 9, 9), new DateTime(1910, 11, 20)));
        await unitOfWork.AuthorsRepository.AddAsync(
            new Author(3, "Марина Ивановна", "Цветаева", new DateTime(1892, 10, 8), new DateTime(1941, 8, 31)));
        
        await unitOfWork.SaveAllAsync();

        await unitOfWork.BooksRepository.AddAsync(
            new Book(1, "На Западном фронте без перемен", 1929, "Роман", 4.6, "https://cv2.litres.ru/pub/c/cover_250/32878920.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(2, "Три товарища", 1936, "Роман", 4.6, "https://cv6.litres.ru/pub/c/cover_250/32544665.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(3, "Черный обелиск", 1956, "Роман", 4.5, "https://cv7.litres.ru/pub/c/cover_250/122478.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(4, "Тени в раю", 1954, "Роман", 4.3, "https://cv3.litres.ru/pub/c/cover_250/4464739.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(5, "Время жить и время умирать", 1954, "Роман", 4.6, "https://cv3.litres.ru/pub/c/cover_250/25298132.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(6, "Ночь в Лиссабоне", 1962, "Роман", 4.5, "https://cv4.litres.ru/pub/c/cover_250/27061646.webp", 1));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(7, "Земля обетованная", 1899, "Роман", 4.3, "https://cv8.litres.ru/pub/c/cover_250/127886.webp", 1));

        await unitOfWork.BooksRepository.AddAsync(
            new Book(8, "Война и мир", 1868, "Роман-эпопея", 4.3, "https://cv6.litres.ru/pub/c/cover_250/69495367.webp", 2));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(9, "Анна Каренина", 1878, "Роман", 4.4, "https://cv5.litres.ru/pub/c/cover_250/28057851.webp", 2));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(10, "Воскресение", 1899, "Роман", 4.4, "https://cv2.litres.ru/pub/c/cover_250/23803525.webp", 2));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(11, "Детство. Отрочество. Юность", 1857, "Повесть-трилогия", 4.0, "https://cv8.litres.ru/pub/c/cover_250/64420187.webp", 2));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(12, "Севастопольские рассказы", 1885, "Цикл рассказов", 4.0, "https://cv7.litres.ru/pub/c/cover_250/25452679.webp", 2));

        await unitOfWork.BooksRepository.AddAsync(
            new Book(13, "Попытка ревности", 2014, "Сборник стихотворей и поэм", 4.3, "https://cv6.litres.ru/pub/c/cover_250/6898561.webp", 3));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(14, "Полное собрание стихотворений", 2008, "Сборник стихотворений", 4.4, "https://cv5.litres.ru/pub/c/cover_250/175853.webp", 3));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(15, "Повесть о Сонечке", 1937, "Повесть", 4.4, "https://cv7.litres.ru/pub/c/cover_250/69324976.webp", 3));
        await unitOfWork.BooksRepository.AddAsync(
            new Book(16, "Пишу на своем чердаке", 2014, "Автобиография", 4.5, "https://cv8.litres.ru/pub/c/cover_250/8051787.webp", 3));

        await unitOfWork.SaveAllAsync();

    }
}
