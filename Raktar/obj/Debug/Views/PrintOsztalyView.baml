   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	   #    Raktar.Views.PrintOsztalyView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   -   5        $��26(�5      
������   � Title$  
Leltárív��5	   	   $	��665��6   $	��925��6'    � WindowStartupLocation$ CenterOwner=�63    � 
ResizeMode$ NoResize=�6W    � WindowStyle$
 None=�6m   .��5
      �� 
������� �� Padding$ 0q�6    ���#2868b0$��4q�6C    �� CornerRadius$ 4��6W   ._�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    61   �� 5      $��* �6    6.   �� 5      $
��auto �6    60    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� $��Center=�6   $��0��68   $��2��6E   .+�5      �� $��Center=�6   
���   �)'Csoportos személyi leltár nyomtatása6s   �� 5      -   5         ��Name$ OsztalyName��5   9   $��Center=�6   6P   �� 5      -   5        $ PersonCount��5   9   $��Center=�6   6P   5      -� 5      $��1��6!   $��16(�6.   $��2��6<   	 -� ViewingMode$	 Scroll=�6n   
 -� Zoom$	
 100Q�6�    -� IsPrintEnabled . ��6P   �� *
Document+5      �� 5      -   5         ��Name$ PrintAll��5   (   $��	40,0,40,0q�6      	AddButton#��[  6;   $��2��6_   .��6l   
Nyomtatás6w   �� 5      -   5        $ 
ExitWindow��5   )   $��	40,0,40,0q�6     DeleteButton#��[ 6=   $��2��6d   $��1��6q   $��2��6�   .��6�   	Kilépés6�   � 5       -   5         �Name$ Progress��5       $��0��6|   $��3��6�   $��3��6�   $��	40,0,40,0q�6�   $��30��6�    � SmallChange$ 1Q�6�    � Cursor$
 Wait��6	   � Maximum 6,   �� *PersonCountForProgress+ � Value 6X   �� *ProgressBarValue+y�6�   �� *ProgressBarVisibilty+6	  5!      5"      5#      