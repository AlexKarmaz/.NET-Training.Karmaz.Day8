# .NET-Training.Karmaz.Day8
## Task1
Дан класс Customer, у которого есть строковые свойства Name, ContactPhone и свойство Revenue типа decimal. Реализовать для объектов
данного класса возможность строкового представления различного вида. Например, для объекта со значениями Name = "Jeffrey Richter", 
Revenue = 1000000, ContactPhone = "+1 (425) 555-0100", могут быть следующие варианты:
* Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100
* Customer record: +1 (425) 555-0100
* Customer record: Jeffrey Richter, 1,000,000.00
* Customer record: Jeffrey Richter
* Customer record: 1000000 и т.д.

Добавить для объектов данного класса дополнительную возможность форматирования (класс при этом не менять!), не предусмотренную классом. 
Разработать unit-тесты.
