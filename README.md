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

N raqamigacha bo'lgan raqamlarni yozish uchun K sonini necha marta yozish kerakligini hisoblang

- [x] Bu controllerga faqat ro'yxatadan otgan foydalanuvchilarni ruxsati bolsin
- [x] Foydalanuvchilarni databazaga saqlang
- [x] Tablega configuration yozing
- [x] Action filter yozing

>Input

- 0 < N < int.MaxValue
- 0 < K < int.MaxValue



>Input #1

### N = 33
### K = 3

>Output #1

### 8
