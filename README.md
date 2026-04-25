# 🎓 Mini School - School Management System

Bu proyekt, modern .NET ekosistemində **Clean Architecture** və **CQRS** pattern-lərinin tətbiqini, həmçinin SOLID prinsiplərini və ən yaxşı arxitektura təcrübələrini (best practices) nümayiş etdirmək məqsədilə hazırlanmış praktiki bir idarəetmə tətbiqidir.

Tətbiq vasitəsilə dərslərin, şagirdlərin və onların imtahan nəticələrinin mərkəzləşdirilmiş şəkildə idarə olunması təmin edilir. Layihə tamamilə genişləndirilə bilən, test edilə bilən və asılılıqların minimuma endirildiyi bir infrastruktur üzərində qurulub.

## 🚀 Texnologiya Stack-i (Tech Stack)

- **Platform & Framework:** .NET 8.0, ASP.NET Core MVC
- **Database Access:** Entity Framework Core 8, MS SQL Server
- **Architecture:** Clean Architecture, Onion Architecture
- **Design Patterns:** - CQRS (Command Query Responsibility Segregation)
  - Repository Pattern (Generic, Derived Command & Query Repositories)
  - Mediator Pattern
- **Libraries & Tools:**
  - **MediatR:** CQRS implementasiyası və decoupling üçün
  - **FluentValidation:** Sorğuların (Requests) və Entity-lərin validasiyası üçün
  - **Riok.Mapperly:** Yüksək performanslı (compile-time) obyekt xəritələnməsi (mapping) üçün
- **Frontend / UI:** Bootstrap 5, jQuery, AJAX (Asinxron əməliyyatlar üçün)

## 🏗️ Arxitektura Quruluşu (Clean Architecture)

Layihə məsuliyyətlərin tam ayrılması (Separation of Concerns) prinsipinə əsasən aşağıdakı qatlara (layers) bölünmüşdür:

1. **Domain:** Tətbiqin nüvəsidir. Bütün Core Business Entity-lər (`Lesson`, `Student`, `Exam`), xüsusi istisnalar (Exceptions) burada yerləşir. Heç bir kənar asılılığı yoxdur.
2. **Shared:** Qatlar arası ortaq istifadə edilən abstraksiyalar (`IBaseEntity`, `BaseRequest`, `IGenericRepository` və s.) cəmlənib.
3. **Application:** Biznes məntiqinin idarə edildiyi qatdır. DTO-lar, Request/Response modelləri, MediatR Handler-ləri və FluentValidation qaydaları burada yerləşir.
4. **Infrastructure & Persistence:** Xarici aləmlə əlaqəni təmin edir. EF Core `DbContext`, Database Configuration-ları, Derived Repository implementasiyaları və qlobal Exception Handler (IExceptionHandler) bu qatdadır.
5. **Presentation (MVC):** İstifadəçi interfeysini və HTTP sorğularını idarə edir. Controller-lər yalnız MediatR vasitəsilə `Application` qatı ilə əlaqəyə girir. UI hissəsində kod təkrarının qarşısını almaq üçün **ViewComponents** istifadə edilmişdir.

## ✨ Əsas Xüsusiyyətlər (Features)

- **Müstəqil Modullar:** Dərs, Şagird və İmtahan modulları üçün tam CRUD əməliyyatları.
- **Bulk Soft-Delete (Archive):** Siyahıdan çoxlu seçilən qeydlərin AJAX və EF Core `ExecuteUpdateAsync` vasitəsilə yüksək performansla arxivlənməsi (IsArchived).
- **Auto-Validation:** Model binding zamanı FluentValidation qaydalarının avtomatik işə düşməsi və istifadəçiyə anında xəta mesajlarının qaytarılması.
- **Qlobal Xəta İdarəetməsi:** Gözlənilməz xətaların mərkəzləşdirilmiş `IExceptionHandler` vasitəsilə idarə edilməsi və istifadəçiyə uyğun formatda göstərilməsi.
- **Performanslı Mapping:** Reflection istifadə edən ənənəvi mapper-lər əvəzinə compile-time işləyən `Riok.Mapperly` tətbiqi.

## 🛠️ Quraşdırma və Çalışdırma (Getting Started)

Proyekti lokal mühitinizdə işə salmaq üçün aşağıdakı addımları izləyin:

### Tələblər (Prerequisites)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MS SQL Server
- Visual Studio 2022 və ya uyğun İDE.

### Addımlar
1. **Repozitoriyanı klonlayın:**
   ```bash
   git clone [https://github.com/ismajil-dev/mini-school.git](https://github.com/ismajil-dev/mini-school.git)
   cd mini-school
