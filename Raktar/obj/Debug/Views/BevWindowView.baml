   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	        Raktar.Views.BevWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5   	   -   5          � Topmost  .  � WindowStyle$
 None=�5
       � AllowsTransparency . 
������  � Title$ Bevételezés��5   	   $	��450��6   $	��800��6*    � WindowStartupLocation$ CenterScreen=�66   .��5      ��  �� Padding$ 0q�6   $��0q�6   
����������#2868b0$��4q�6M    �� CornerRadius$ 4��6a   ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $��20 �6    �� 5      $��40 �6    .+�5      �� 
�������$��Center=�6-   $��0��6H   .+�5      �� -   5         ��Name$ AddCikk��5      $
��Left=�6+   $��14(�6F   $	��130��6U   $��40��6a   .��6m   Cikk kiválasztása6�   � 5      $��0,0,25,5q�6   $��Center=�6+   	 � ColumnDefinitions	 5      �� 5      $
��auto �6+   �� 5      $��* �6+   �� 5      $
��auto �6+   �� 5      $��2* �6+   �� 5      $
��auto �6+   �� 5       $
��0.5* �6+   �� 5!      $
��auto �6+   �� 5"      $
��0.5* �6+   .+�5$      �� $��5,0,5,0q�6    $��Center=�61   Cikkszáma:6X   �� 5&      -   5        
 ��Name$
 Number��5&   �      DesignedTextBox#��[  6   $��1��6H   " �� VerticalScrollBarVisibility$
 Auto=�6X    �� 
IsReadOnly . $��5,0,5,0q�6�   $��Center=�6�   6�   �� 5(      $��2��6    $��5,0,5,0q�61   $��Center=�6B   Megnevezés:6j   �� 5*      -   5        $	
 Nev��5*   W   #��[  6   $��3��6G   $
 Auto=�6d    . $��5,0,5,0q�6�   $��Center=�6�   6�   �� 5,      $��4��6    $��5,0,5,0q�61   $��Center=�6B   
Mennyiség6h   �� 5.      -   5        $
 Count��5.   X   #��[  6   $��5��6G   $��5,0,5,0q�6j   $��Center=�6{   $��Center=�6�   .��6�   05/      �� 51      $��6��6    $��80��62   $��5,0,5,0q�6=   $��Center=�6N   Mértékegység:52   $   �� 54      -   5        $

 Unit��54   j   #��[  6    . $��7��6Z   $��5,0,5,0q�6y   $��Center=�6�   58      �� 59       �� Orientation$ 
Horizontal=�6   .+�5:      �� $��50��6!   $��5,0,5,0q�6,   $��Center=�6=   Egységár:5;      �� 5=      -   5        $
 Price��5=      #��[  6.   $��50��6X   $��20��6c   $��Center=�6p   $��Center=�6�   .��6�   5>      �� 5@      $��5,0,5,0q�6    $��Center=�61   
Partner:6V   �� 5A      -   5         ��Name$ 	Partnerek��5A   O   $��5,0,5,0q�6b   $��25��6s   $	��100��6    �� DisplayMemberPath$
 Name��6�   {�6    ��  �� Path$ SzamlaSzamIsEnabled� �� SelectedItem 6�   �� *	Partner+5B      �� 5C      $��5,0,5,0q�6    $��Center=�61   Számlaszám:6Y   �� 5E      -	   5        $
 
Szamlaszam��5E   �   #��[  6   $	��100��6v   $��Center=�6�   {�6G   �� $ SzamlaSzamIsEnabled�6�   �� 5G      -
   5        $ AddCikkToGrid��5G      $��5q�64   .��6A   Cikk hozzáadása6R   5H      5I      &   System.Windows.Controls.DataGrid  5K      -   5          Name$ Ruhak��5K   V   $��5q�6   "   VerticalScrollBarVisibility$
 Auto=�6&   $��1��6I     Caliburn.Micro.Message   Attach$7 1[Event CurrentCellChanged] = [Action CellEdited] ��6e    � Cursor$
 Hand��6�      CanUserAddRows .     CanUserDeleteRows .    AutoGenerateColumns .   �� AlternationCount$ 1��6	     SelectionMode$ Single=�6     Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6-      Header$ 	Cikkszám��67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� $ Cikkszam�6m     5N      $ * 6-   $ Cikknév��67    6H   �� $ Cikknev�6k     5O      $ * 6-   $ 
Mennyiség��67    6J   �� $ 	Mennyiseg�6o     5P         
IsReadOnly . $ * 6?   $ Mértékegység��6I    6_   �� $ Mertekegyseg�6�     5Q      $ * 6-   $ 
Egységár��67    6I   �� *
Egysegar+  �� StringFormat$  {0:C0}��! �� ConverterCulture$! hu-HU��6�     5R       . $ * 6?   $ 	Összesen��6I    6[   �� *
Osszesen+$  {0:C0}��$! hu-HU��6�     5S       . $ * 6?   $ Partner��6I    6Z   �� $ Partner�6}   5V      �� 5X      $��2��6   $��Center=�6&   $ 
Horizontal=�6A   $��Right=�6Z   .+�5Y      �� 	Összsen:6'   �� 5Z      $
��Bold"�6   $��	10,0,20,0q�6n   ��6.   �� *Sum+$  c0��$! hu-HU��6�   5[      �� 5\      $��2��6   $��2��6&   $��Center=�67   $��Center=�6R   $ 
Horizontal=�6o   .+�5]      �� -   5        $
 Save��5]      $	��100��6'   $��45��63   $��0,0,60,0q�6?   .��6Q   	Mentés5_      �� 5`      -   5        $
 Exit��5`      $	��100��6'   $��45��63   .��6?   	Kilépés5b      5c      5d      5e      5f      