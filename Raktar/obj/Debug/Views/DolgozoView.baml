   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5          Raktar.Views.DolgozoView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Raktar.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   .+�5      �� $��0,5,5,5q�6    �� Orientation$ 
Horizontal=�6*   .+�5      �� -   5         ��Name$ KivalasztDolgozo��5   %   $��50��6   $��Center=�6?   $
��Left=�6Z   .��6x   Dolgozó kiválasztása6�   �� 5      $��Center=�6   $��5,5,0,5q�68   Kiválasztott dolgozó:6`   �� 5      -   5         ��Name$ 
WorkerName��5   g   $
��Bold"�6   $��Center=�6/   $��Center=�6L   $��5,0,0,0q�6{   6�   �� 5      $��Center=�6   $��Center=�69   $��5,0,0,0q�6U   -6i   �� 5      -   5        $ WorkerGroup��5   f   $
��Bold"�6   $��Center=�6.   $��Center=�6K   $��5,0,0,0q�6{   6�   5      �� 5      $��0 0 0 5q�6B   $ 
Horizontal=�6S   {�6   �� *DolgozoKivalasztva+.+�5      �� -   5        $ 	Visszavet��5      $	��100��6,   $��50��68   .��6E   Visszavétel6R   �� 5      -   5        $ 	Kivezetes��5      $	��100��6-   $��50��69   .��6F   
Kivezetés6Q   �� 5      -   5        $ 	Megvaltas��5      $	��100��6-   $��50��69   .��6F   Megváltás6R   �� 5      -   5        $ 	Nyomtatas��5      $	��100��6-   $��50��69   .��6F   
Nyomtatás6Q   5      5      &   System.Windows.Controls.DataGrid  5!      -   5          Name$ Ruhak��5!   l   $��1��6   "   VerticalScrollBarVisibility$
 Auto=�6$   $   HorizontalScrollBarVisibility$
 Auto=�6G   $��16(�6|      
IsReadOnly .  � Cursor$
 Hand��6�   
���   �	   AutoGenerateColumns	 .  
 �� AlternationCount$
 1��6�      SelectionMode$ Single=�6�      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6F      Header$ 	Cikkszám��6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Cikkszam+6e     5$      $ * 6E   $ Cikknév��6O    6)   �� *	Cikknev+6b     5%      $ * 6I   $ Cikkcsoport��6S    6)   �� *Cikkcsoport+6j     5&      $ * 6G   $ 
Mennyiség��6Q    6)   �� *	Mennyiseg+6f     5'      $ * 6J   $ Mértékegység��6T    6)   �� *Mertekegyseg+6l     5(      $ * 6w   $ 
Egységár��6�    6)   �� *
Egysegar+ �� StringFormat$ {0:C0}�� �� ConverterCulture$ hu-HU��6�     5)      $ * 6w   $ 	Összesen��6�    6)   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5*      $ * 6E   $ Partner��6O    6)   �� *	Partner+6b     5+      $ * 6F   $ Kiadás��6P    6)   �� *
Bevdatum+6b   5-      �� 50   
   $	��0 5q�6   $��2��6"   $��Center=�6/   $ 
Horizontal=�6J   $��Right=�6c   .+�51      �� 
Összesen:6$   �� 52      -	   5        $	 Sum��52      $
��Bold"�6%   $��10,0,0,0q�6w   ��67   �� *Sum+$ c0��$ hu-HU��0 Ft6�   53      54      55      