   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5      "    Raktar.Views.CikkekTorzsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Raktar.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5	      $	��400��5      $	��200��5      .��5
      � $��15q�6     � RowDefinitions  5      �� 5   
   $��40 �6   �� 5   
   $��30 �6   �� 5   
   $��* �6   �� 5   
   $��40 �6   .+�5      �� $
��Bold"�6   ���#2868b0$��20(�67   $��Center=�6E   $��Center=�6`   Cikkek6�   �� 5   
   -   5         ��Name$ 
SearchCikk��5   5      	SearchBox#��[  6   $��16(�6I   $��1��6X   $��Center=�6e     Caliburn.Micro.Message   Attach$� �[Event KeyUp] = [Action SearchingForRuha($executionContext)]; [Event LostFocus] = [Action LostFocus()]; [Event GotFocus] = [Action OnFocus]��6�   .��6(  Keresés...64  �� 5      -   5         ��Name$ SearchableRuha��5       �� DisplayMemberPath$ NameForCikk��6&   $��16(�6F   $��2��6T   $D >[Event MouseDoubleClick] = [Action DoubleClickMunkaruhaList()]��6a    �� SelectedItem 6�   �� *SelectedMunkaruha+5      � 5      $��3��6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ AddCikk��5      $��0��6#     	AddButton#��[ 63   .��6Z   
Hozzáad6c   �� 5   
   -   5        $ 
RemoveCikk��5        DeleteButton#��[ 6%   $��1��6L   .��6^   
Törlés6f   5      5      5      