   M S B A M L   `   `   `  ����
  Raktar$    Raktar.Views.BevetelezesekView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   
������ $	��450��5	   	   $	��800��6   .��5
      �   � RowDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �� $��Center=�6    �� TextAlignment$ Center=�63   Partner kiválastása:6a   �� 5      -   5         ��Name$ 	Partnerek��5   t   $��5q�6    �� DisplayMemberPath$
 Name��6K   $	��100��6e    �� SelectedItem 6"   �� *SelectedPartner+6�   �� 5      $��Center=�6   $ Center=�63   $��16(�6J   $��5q�6X   Bevételezés kiválasztása6}   �� 5      -   5        $ Bevetelezesek��5   1   $��5q�6   $	��100��6"   $ 
Szamlaszam��6q    6H   �� *Selectedbevetel+6q   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Ruhak��5      $��1��6"   $��16(�6/    � Cursor$
 Hand��6=      
IsReadOnly . 
���   �	   AutoGenerateColumns	 .  
 �� AlternationCount$
 1��6�      SelectionMode$ Single=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Cikk Kód��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
Cikkszam+6`     5      $ Cikk Megnevezése��6%   $ 2* 6[    6?   �� *	Cikknev+6h     5      $ 
Mennyiség��6%   $
 auto 6V    68   �� *	Mennyiseg+6f     5      $ Mértékegység��6%   $
 auto 6\    6;   �� *Mertekegyseg+6l     5      $ 
Egységár��6%   $ * 6�    67   �� *
Egysegar+ �� StringFormat$ {0:C0}�� �� ConverterCulture$ hu-HU��6�     5      $ 	Összesen��6%   $ * 6�    67   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5      $ Partner��6%   $ * 6R    66   �� *	Partner+6^   5"      � 5#   
   $��2��6    � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $
��auto �6#   .+�5)      �� $��0 0 0 5q�6   $��Center=�6*   $��Right=�6E   $��1��6a   $ 
Horizontal=�6q   .+�5*      �� $��5q�6   
Összesen:62   �� 5+      -   5         ��Name$	 Sum��5+   '   $��5q�6   $
��Bold"�64   0 Ft6M   5,      5-      5/      50      