   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5          Raktar.Views.RaktarView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Raktar.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��5 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��5 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ RaktarCikkek��5   H   $��0 0 0 5q�6   "   VerticalScrollBarVisibility$
 Auto=�6$   $��2��6^   $��2��6k   $��16(�6|      
IsReadOnly .  � Cursor$
 Hand��6�   
���   �   AutoGenerateColumns .   �� AlternationCount$ 1��6�      SelectionMode$ Single=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6B   
   Header$
 	Cikkszám��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Cikkszam+6a     5      $	 * 6A   $
 Cikknév��6K    6%   �� *	Cikknev+6^     5      $	 * 6E   $
 Cikkcsoport��6O    6%   �� *Cikkcsoport+6f     5      $
	 auto 6C   $
 
Mennyiség��6P    6%   �� *	Mennyiseg+6e     5      $
	 auto 6F   $
 Mértékegység��6S    6%   �� *Mertekegyseg+6k     5      $	 * 6s   $
 
Egységár��6}    6%   �� *
Egysegar+ �� StringFormat$ {0:C0}�� �� ConverterCulture$ hu-HU��6�     5      $	 * 6s   $
 	Összesen��6}    6%   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5      $	 * 6A   $
 Partner��6K    6%   �� *	Partner+6^     5      $	 * 6B   $

 Bev.��6L    6%   �� *
Bevdatum+6\   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5       $	��160 �6#   �� 5!      $	��160 �6#   .+�5#      �� -   5         ��Name$ 	Bevetelez��5#   !   $��50��6   $��0��65   .��6E   Bevételezés6R   �� 5$      -   5        $
 Kiad��5$      $��1��6%   .��65   	Kiadás6=   5%      5&      5'      