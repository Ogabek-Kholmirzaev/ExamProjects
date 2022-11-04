# 1. Masala - Console applicationda qiling

Karra jadvali - N sonini karra jadvalini chop eting.
Input - Bitta butun N son(2 <= N < 10).
Output - N sonining karra jadvalini chop eting va natijani SQLitega saqlang. 
Agar kiritilgan sonni natijasi databaseda mavjud bo'lsa databasedagi natijani chop eting. 
>Input

3

>Output

- 1*3 = 3
- 2*3 = 6
- ...
- 9*3 = 27

# 2. Masala - WebApida qiling

A dan B gacha yig'indini hisoblang.
Kiritilgan sonlar A≤B A≤B shartga to'g'ri kelmasa xatolikni chiqaring
Natijalarni json ko'rinishida faylga saqlang
```C#
class Log
{
   string Input1;
   string Input2;
   string Output;
   Datetime Date{get;set};
}
```

- Input - Ikkita butun sonlar A va B
- Output - A dan B gacha yig'indini chiqaring.

Input
>4

>8

Output
>30

# 3. Masala - MVC da qiling
Kiritilgan sonni so'zma-so'z chiqaring
 - So'zlarni databasedan oling
 - Inputda faqat son kiritilsin

Input #1
> 123

Output #1 
>bir yuz yigirma uch

Input #2 
>1001001111 

Output #2 
>bir milliard bir million bir ming bir yuz o'n bir

# 11.02.2022 - WebApi

N sonigacha bo'lgan raqamlarni yozish uchun K raqami necha marta yozish kerakligini hisoblang

- [x] Bu controllerga faqat ro'yxatadan otgan foydalanuvchilarni ruxsati bolsin
- [x] Foydalanuvchilarni databazaga saqlang
- [x] Tablega configuration yozing
- [x] Action filter yozing

>Input

- 0 < N < int.MaxValue
- 0 <= K <= 9



>Input #1

### N = 33
### K = 3

>Output #1

### 8

# 3.11.2022 - WebApi

> Description
1 dan boshlab kiritilgan N butun sonigacha bo'lgan barcha sonlarga bo'linadigan eng kichik sonni topadigan dastur tuzing.

- [x] Bu controllerga faqat ro'yxatadan otgan foydalanuvchilarni ruxsati bolsin
- [x] Foydalanuvchilarni json faylga saqlang
- [x] json faylni manzil(path)ini *appsettings.json* faylga yozing
- [x] json faylni manzil(path)ini *appsettings.json* faylidan oqib oling
- [x] *appsettings.json* faylini oqib olishda `IOption<T>` servicedan foydalaning
- [ ] `AuthenticationHandler` yozing
- [x] `RoleFilter` (`ActionFilterAttribute`) yozing
- [x] Foydalanuvchilarni ruxsatini `RoleFilter` orqali aniqlang

>Input
- 0 < N < int.MaxValue

>Input #1

### N = 5

>Output #1

### 60
