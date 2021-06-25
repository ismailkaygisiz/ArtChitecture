# ArtChitecture
## ASP.Net Web API, Flutter ve Angular Kullanarak Çapraz Platform Bağımsız Uygulama Geliştirme Mimarisi
<br>

---
<br>

## Gereklilikler

---

<br>

- ### Sürümler

  - Angular CLI 11.2.3.
  - .Net 5
  - .Net Standart 2.0
  - Flutter

    Sürümlerle ilgili ayrıntıyı bilgiye projelerin içinde bulunan `.csproj` dosyalarından ve [Dependencies](https://github.com/ismailkaygisiz/ReCapProject/network/dependencies) üzerinden erişebilirsiniz.

    Angular projesinde kullanılan modüllere ve sürümlere Angular projesinin içinde bulunan `package.json` ve `package-lock.json` dosyalarından erişebilirsiniz.

    Flutter projesinde kullanılan paketlere ve sürümlere Flutter projesi içinde bulunan `pubspec.yaml` dosyası üzerinden erişebilirsiniz.

- ### Uygulamalar

  - <b>BackEnd</b>

    - .Net 5 ve .Net Standart 2.0 derleyebilecek herhangi bir geliştirme ortamı.

  - <b>FrontEnd</b>

    - Angular CLI 11.2.3 derleyebilecek herhangi bir geliştirme ortamı.

    - Flutter derleyebilecek herhangi bir geliştirme ortamı.

---

<br>

## BackEnd için Yapılması Gerekenler

---

<br>

- ### Veritabanı Etkinleştirme

  ...

  <br>

- ### Projeyi Çalıştırma

  Klasör içinde bulunan `.sln` uzantılı dosya açılmalıdır daha sonra `WebAPI` başlangıç projesi
  olarak işaretlenmeli ve proje build edildikten sonra çalıştırılmalıdır. Eğer önünüzde kullanıcılar varsa tebrikler
  artık API çalışıyor. Açılan sekmedeki port adresini kopyalayın.

---

<br>

## FrontEnd için Yapılması Gerekenler

<br>

- ### Angular Projesini API' ye Entegre Etme

  Dosya yolu üzerinden AngularUI dizini içinde bulunan ReCapProject projesini Angular çalıştırabileceğiniz bir editörle açın. Daha sonra `src/api.ts` dosyasına giderek kopyaladığınız port adresini gerekli yerlere yapıştırın. Bu işlemi yaparken apiUrl değişkeninde `/api/` ifadesinin olmasına dikkat edin.
  Projeyi ilk indirdiğiniz api dosyasının içeriğinin aşağıdaki gibi olduğunu göreceksiniz.

  ```
  export const apiUrl = http://localhost:5001/api/;
  export const imageUrl = http://localhost:5001/;
  ```

  Bu adresleri kendi port adresinize göre değiştirmelisiniz. Örn: port adresiniz 44311 ise dosyanın içeriği aşağıdaki gibi olmalıdır.

  ```
  export const apiUrl = http://localhost:44311/api/;
  export const imageUrl = http://localhost:44311/;

  ```

  <br>

- ### Angular Projesi için Gerekli Modülleri Kurma

  Angular dosya dizini içinde yeni bir terminal oluşturup `npm install` komutunu yazmanız yeterlidir Angular proje için gerekli paketleri kuracaktır.

  <br>

- ### Angular Projesini Çalıştırma

  Kurulum işlemi bittikten sonra yapmanız gereken terminale `ng serve --open --port 4200` komutunu yazmak olacaktır. Eğer bu port meşgulse veya çalışmıyorsa port adresini değiştirmelisiniz. Port adresini değiştirdiğinizde `WebAPI/Startup.cs` içindeki

  `app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());`

  kısmını düzenlemeniz gerekir sadece url değiştirmeniz yeterli olacaktır bu işlemden sonra WebAPI'yi durdurup tekrar çalıştırmanız gerekecektir.

---

<br>

- ### Flutter Projesini Çalıştırma

  ...
