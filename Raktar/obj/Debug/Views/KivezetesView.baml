   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	        Raktar.Views.KivezetesView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   -   5          � WindowStyle$
  None=�5       � AllowsTransparency . 
������  � Title$ 
Kivezetés��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5      ��  �� Padding$ 0q�6   $��0q�6   
����������#2868b0$��4q�6M    �� CornerRadius$ 4��6a   ._�5   
   �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6"   .+�5      �� .��5      �� .+�5      �� $��5q�6!   $ 
Horizontal=�6,   .+�5      �� $��0,0,10,0q�6$   Név:6<   �� 5      $
��Bold"�6$   $	��100��66   $��0,0,10,0q�6c   ��6E   �� *Dolgozo.Name+6w   �� 5      $��0,0,10,0q�6$   	Osztály:6@   �� 5      $
��Bold"�6$   $	��100��66   $��0,0,10,0q�6h   ��6E   �� *Dolgozo.GroupName+6|   5      �� 5      $��Center=�6"   $��0��6=   $��5,0,5,0q�6J   .+�5      �� $ 
Horizontal=�6%   .+�5       �� $��Center=�6(   $��5,0,5,0q�6C   Cikk kiválasztása6g   �� 5!      -   5         ��Name$ Cikkek��5!   J   $��5q�6Z   	 �� DisplayMemberPath$	 NameForCikk��6e   $��Center=�6�   $
��Left=�6�   $	��150��6�   $��25��6�   
 �� SelectedItem
 6'   �� *	Munkaruha+6�   5"      �� 5$      $��0,0,0,5q�6%   $��Center=�67   $ 
Horizontal=�6R   .+�5%      �� $��5,0,5,0q�6(   $��Center=�69   Cikkszáma:6`   �� 5&      -   5         ��Name$ Number��5&   �    �� 
IsReadOnly .    DesignedTextBox#��[  69   $
��Bold"�6�   $��65��6�   $��5,0,5,0q�6�   $��Center=�6�   ��6b   �� *Munkaruha.Cikkszam+6�   �� 5'      $��5,0,5,0q�6(   $��Center=�69   Megnevezés:6a   �� 5(      -   5        $ CikkName��5(   �    . #��[  68   $
��Bold"�6�   $��90��6�   $��5,0,5,0q�6�   $��Center=�6�   ��6a   �� *Munkaruha.Cikknev+6�   �� 5)      $��5,0,5,0q�6(   $��Center=�69   
Mennyiség6_   �� 5*      -   5        $ Count��5*   O   #��[  6&   
���   �$��1q�6r   $��50��6�   $��5,0,5,0q�6�   $��Center=�6�   $��Center=�6�   .��6�   5+      �� 5,      $��5,0,5,0q�6)   Személynél:6G   �� 5-      -   5        $	 Max��5-   �    . #��[  68   $
��Bold"�6�   $��5,0,5,0q�6�   $��Center=�6�   $��30��6�   ��6a   �� *Munkaruha.Mennyiseg+6�   �� 5.      $��80��6*   $��5,0,5,0q�65   Mértékegység:5/   $   �� 51      -   5        $
 Unit��51   �    . #��[  69   $
��Bold"�6�   $��50��6�   $��5,0,5,0q�6�   $��Center=�6�   ��6b   �� *Munkaruha.Mertekegyseg+.��6�   52      55      �� 56      $ 
Horizontal=�6%   .+�57      �� $��50��6)   $��5,0,5,0q�64   $��Center=�6E   
Egységár58      �� 5:      -   5        $ Price��5:   �    . #��[  68   $
��Bold"�6�   $��50��6�   $��5,0,5,0q�6�   $��Center=�6�   ��6a   �� *Munkaruha.Egysegar+ �� StringFormat$ c0�� �� ConverterCulture$ hu-HU��.��6  5;      �� 5=      $��5,0,5,0q�6(   $��Center=�69   
Partner:6^   �� 5>      -	   5        $ Partner��5>   �    . #��[  68   $
��Bold"�6�   $��Center=�6�   $��5,0,5,0q�6�   $	��100��6�   ��6a   �� *Munkaruha.Partner+.��6�   5?      �� 5@      -
   5         ��Name$ AddCikkToGrid��5@   %   $��5q�6<   $��45��6G   .��6T   Cikk hozzáadása6e   5A      5B      5C      5D      5F      �� 5G   
   $��5q�6   $��1��6"   .��5H      &   System.Windows.Controls.DataGrid  -   5          Name$ Ruhak��5H       � Cursor$
 Hand��6'      AutoGenerateColumns .     
IsReadOnly .  �� AlternationCount$ 1��6f      SelectionMode$ Single=�6{      Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ 	Cikkszám��63   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   ��  �� Path$ Cikkszam�6i     5K      $ * 6)   $ Cikknév��63    6D   �� $ Cikknev�6g     5L      $
 auto 6)   $ 
Mennyiség��66    6I   �� $ 	Mennyiseg�6n     5M      $
 auto 6)   $ Mértékegység��66    6L   �� $ Mertekegyseg�6t     5N      $ * 6)   $ 
Egységár��63    6E   �� *
Egysegar+$ {0:C0}��$ hu-HU��6�     5O      $ * 6)   $ 	Összesen��63    6E   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5P      $ * 6)   $ Partner��63    6D   �� $ Partner�6g   5R      5S      �� 5U   
   $��5q�6   $��2��6    $��2��6-   $��Center=�6>   $��Center=�6Y   $ 
Horizontal=�6v   .+�5V      �� -   5        $
 Save��5V      $	��100��6#   $��45��6/   $��0,0,60,0q�6;   .��6M   	Mentés5X      �� 5Y      -   5        $ CloseWindow��5Y      $	��100��6*   $��45��66   .��6B   	Kilépés5[      5\      5]      5^      5_      