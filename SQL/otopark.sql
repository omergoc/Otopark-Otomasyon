-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 29 Oca 2021, 16:18:16
-- Sunucu sürümü: 10.4.17-MariaDB
-- PHP Sürümü: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `otopark`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `aboneler`
--

CREATE TABLE `aboneler` (
  `abone_id` int(11) NOT NULL,
  `abone_tip` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `abone_sure` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `abone_bas_tarihi` varchar(200) COLLATE utf8_turkish_ci NOT NULL,
  `abone_bitis_tarih` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `abonelik_ucret` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `aboneler`
--

INSERT INTO `aboneler` (`abone_id`, `abone_tip`, `abone_sure`, `abone_bas_tarihi`, `abone_bitis_tarih`, `abonelik_ucret`) VALUES
(6, 'Deneme', 'Deneme', '28.01.2021 14:46:51', '29.01.2021 14:46:51', 500),
(7, 'Deneme2', 'Deneme2', '31.01.2021 14:46:51', '5.02.2021 14:46:51', 500);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `araclar`
--

CREATE TABLE `araclar` (
  `arac_id` int(11) NOT NULL,
  `arac_plaka` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `arac_renk` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `arac_model` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `arac_yil` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `araclar`
--

INSERT INTO `araclar` (`arac_id`, `arac_plaka`, `arac_renk`, `arac_model`, `arac_yil`) VALUES
(2, '34RG122', 'Kirmizi', 'Renault', 2010),
(4, '34 AA 1923', 'Sari', 'Skoda', 2010);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hizmetler`
--

CREATE TABLE `hizmetler` (
  `hizmet_id` int(11) NOT NULL,
  `hizmet_musteri` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `hizmet_arac` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `hizmet_baslangic` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `hizmet_bitis` varchar(250) COLLATE utf8_turkish_ci NOT NULL,
  `hizmet_ucret` int(11) NOT NULL,
  `hizmet_abonelik` varchar(250) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `hizmetler`
--

INSERT INTO `hizmetler` (`hizmet_id`, `hizmet_musteri`, `hizmet_arac`, `hizmet_baslangic`, `hizmet_bitis`, `hizmet_ucret`, `hizmet_abonelik`) VALUES
(3, 'Deneme', '34 AA 1923', '29 Ocak 2021 Cuma', '30 Ocak 2021 Cumartesi', 150, 'Deneme2');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteriler`
--

CREATE TABLE `musteriler` (
  `musteri_id` int(11) NOT NULL,
  `musteri_ad_soyad` varchar(100) COLLATE utf8_turkish_ci NOT NULL,
  `musteri_tel_no` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `musteri_adres` varchar(500) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `musteriler`
--

INSERT INTO `musteriler` (`musteri_id`, `musteri_ad_soyad`, `musteri_tel_no`, `musteri_adres`) VALUES
(5, 'Deneme', '05454', 'denemeadres1');

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `aboneler`
--
ALTER TABLE `aboneler`
  ADD PRIMARY KEY (`abone_id`);

--
-- Tablo için indeksler `araclar`
--
ALTER TABLE `araclar`
  ADD PRIMARY KEY (`arac_id`);

--
-- Tablo için indeksler `hizmetler`
--
ALTER TABLE `hizmetler`
  ADD PRIMARY KEY (`hizmet_id`);

--
-- Tablo için indeksler `musteriler`
--
ALTER TABLE `musteriler`
  ADD PRIMARY KEY (`musteri_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `aboneler`
--
ALTER TABLE `aboneler`
  MODIFY `abone_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Tablo için AUTO_INCREMENT değeri `araclar`
--
ALTER TABLE `araclar`
  MODIFY `arac_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tablo için AUTO_INCREMENT değeri `hizmetler`
--
ALTER TABLE `hizmetler`
  MODIFY `hizmet_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tablo için AUTO_INCREMENT değeri `musteriler`
--
ALTER TABLE `musteriler`
  MODIFY `musteri_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
