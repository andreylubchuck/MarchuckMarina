

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

-- 
-- База данных: `cocktails`
-- 

-- --------------------------------------------------------

-- 
-- Структура таблицы `account`
-- 

CREATE TABLE IF NOT EXISTS `account` (
  `ID` int(11) NOT NULL auto_increment,
  `login` varchar(45) collate utf8_unicode_ci NOT NULL,
  `password` varchar(45) collate utf8_unicode_ci NOT NULL,
  `type` tinyint(4) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=4 ;

-- 
-- Дамп данных таблицы `account`
-- 

INSERT INTO `account` (`ID`, `login`, `password`, `type`) VALUES 
(1, 'barmen', '111', 1),
(2, 'user', '222', 2),
(3, 'whman', '333', 3);

-- --------------------------------------------------------

-- 
-- Структура таблицы `recipes`
-- 

CREATE TABLE IF NOT EXISTS `recipes` (
  `ID` int(11) NOT NULL auto_increment,
  `name` varchar(45) collate utf8_unicode_ci NOT NULL,
  `liquid` varchar(45) collate utf8_unicode_ci NOT NULL,
  `ice` varchar(45) collate utf8_unicode_ci NOT NULL,
  `decoration` varchar(45) collate utf8_unicode_ci NOT NULL,
  `price` int(11) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=4 ;

-- 
-- Дамп данных таблицы `recipes`
-- 

INSERT INTO `recipes` (`ID`, `name`, `liquid`, `ice`, `decoration`, `price`) VALUES 
(1, 'Mohito', 'jin', 'crashed', 'mint', 20),
(2, 'Bloody Mary', 'tomat_juice', '', '', 10),
(3, 'Malibu', 'malibu', 'cubed', 'cherry', 25);

-- --------------------------------------------------------

-- 
-- Структура таблицы `warehouse`
-- 

CREATE TABLE IF NOT EXISTS `warehouse` (
  `name` varchar(45) collate utf8_unicode_ci NOT NULL,
  `portions` int(11) NOT NULL,
  PRIMARY KEY  (`name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- 
-- Дамп данных таблицы `warehouse`
-- 

INSERT INTO `warehouse` (`name`, `portions`) VALUES 
('tomat_juice', 5),
('jin', 3),
('mint', 2),
('malibu', 0),
('cherry', 9);
