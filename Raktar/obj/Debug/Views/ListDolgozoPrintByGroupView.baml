   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5      .    (Raktar.Views.ListDolgozoPrintByGroupView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Raktar.Views     5      -   5          � WindowStyle$
  None=�5       � AllowsTransparency . 
������  � WindowStartupLocation$ CenterOwner=�5      .��5      ��  �� Padding$ 0q�6   $��0q�6   ���#2868b0$��4q�6;    �� CornerRadius$ 4��6O   ._�5   
   � 
������� � RowDefinitions 5      �� 5      $��0 �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $��0 �6    .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ RaktarCikkek��5      $��2��6.   $��2��6;   $��16(�6L      
IsReadOnly .  � Cursor$
 Hand��6l   
���   �	   AutoGenerateColumns	 .  
 �� AlternationCount$
 1��6�      SelectionMode$ Single=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6F      Header$ 	Cikkszám��6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Cikkszam+6e     5      $ * 6E   $ Cikknév��6O    6)   �� *	Cikknev+6b     5      $ * 6I   $ Cikkcsoport��6S    6)   �� *Cikkcsoport+6j     5      $
 auto 6G   $ 
Mennyiség��6T    6)   �� *	Mennyiseg+6i     5      $
 auto 6J   $ Mértékegység��6W    6)   �� *Mertekegyseg+6o     5      $ * 6w   $ 
Egységár��6�    6)   �� *
Egysegar+ �� StringFormat$ {0:C0}�� �� ConverterCulture$ hu-HU��6�     5      $ * 6w   $ 	Összesen��6�    6)   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5      $ * 6E   $ Partner��6O    6)   �� *	Partner+6b     5       $ * 6F   $
 Bev.��6P    6)   �� *
Bevdatum+6`   5"      � 5$      $��0,0,0,0q�6   ���#f1f3f4$��1��69    � ColumnDefinitions 5%      �� 5&      $
��auto �6'   �� 5'      $	��26* �6'   �� 5(      $
��104* �6'   �� 5)      $
��130* �6'   �� 5*      $
��130* �6'   �� 5+      $
��129* �6'   �� 5,      $
��129* �6'   �� 5-      $
��129* �6'   �� 5.      $��10 �6'    50      �� 51      $��10 �6$   �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $��* �6$   �� 56      $��10 �6$   .+�58      �� -   5         ��Name$ OsztalyokLabel��58   U   $��18(�6   $��Center=�6&   $��3��6A   $��1��6m   $��1��6z   $	��0,3q�6�   .��6�   Osztály kiválasztása:6�   �� 59      -   5         ��Name$ Groups��59   '   $��30��6    �� DisplayMemberPath$
 Name��6�   $��50,5,0,5q�6�   $��18(�6�   $��1��6�   $��3��6�   $��3��6�    �� SelectedItem 67   �� *Group+ �� SelectedIndex 6V   �� *SelectedGroupIndex+6�   �� 5:      -   5         ��Name$ 
ExitButton��5:         DeleteButton#��[  6-   $��1��6S   $��7��6`   .��6p   	Kilépés6y   �� 5;      -   5        $ Elonezet��5;        	AddButton#��[ 6,   $��1��6O   $��6��6\   .��6l   
Előnézet6v   5<      5=      5>      5?      