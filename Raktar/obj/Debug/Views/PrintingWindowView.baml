   M S B A M L   `   `   `  ����A  =Raktar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Raktar.ViewsRaktar.Views  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5   	   %    Raktar.Views.PrintingWindowView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Raktar.Views     5   	   ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5   	   ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5	   	     � Title$  
Nyomtatás��5
   	   $	��821��6   $
��1000��6(    � WindowStartupLocation$ CenterScreen=�65    � 
ResizeMode$ NoResize=�6Z   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   ,� .��5      /� -   5         /�Name$ Document��5       /� 
FontFamily$ Arial)�6.    /� FontSize$ 20(�6A   .T�5      �� .r�5      �� $1��+/Raktar;component/Pictrures/fejlecvajda.jpg��6   6S   5      �� 5       �� Margin$ 0,30,0,0q�6#    �� TextAlignment$ Center=�65   $��40(�6L   .r�5      �� $��Center=�6!   .+�5      �� $��Center=�6$   	Leltár6I   �� 5      $��Center=�6$   ��6A   �� *Dolgozo.Name+6a   5      5      J� 5      $ Center=�6   $��20(�65   .*�6D   .*�5      &   System.Windows.Controls.DataGrid  $	��860��6   	   
IsReadOnly	 . 
   AutoGenerateColumns
 .   �� AlternationCount$ 1��6y      HeadersVisibility$ Column=�6�   ��6+   �� *Ruhak+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 16Q�61      
FontFamily$ Arial)�6?   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6o      Header$ 	Cikkszám��6y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *
Cikkszam+6�     5      $ 16Q�61   $ Arial)�6?   $
 2.5* 6n   $ Cikknév��6{    6R   �� *	Cikknev+6�     5       $ 16Q�61   $ Arial)�6?   $
 0.5* 6p   $	 Me.��6}    6R   �� *	Mennyiseg+6�     5!      $ 16Q�61   $ Arial)�6?   $
 0.7* 6s   $ 
Me.egység��6�    6R   �� *Mertekegyseg+6�     5"      $ 16Q�61   $ Arial)�6?   $ * 6�   $ 
Egységár��6�    6R   �� *
Egysegar+ �� StringFormat$ {0:C0}�� �� ConverterCulture$ hu-HU��6�     5#      $ 16Q�61   $ Arial)�6?   $ * 6�   $ 	Összesen��6�    6R   �� *
Osszesen+$ {0:C0}��$ hu-HU��6�     5$      $ 16Q�61   $ Arial)�6?   $ * 6o   $ Kiadás��6y    6R   �� *
Bevdatum+6�   5&      5(      J� 5)      $��25(�6   $ Right=�6+   .*�6A   .*�5*      �� $��Center=�6#    �� Orientation$ 
Horizontal=�6>   $��Right=�6W   .+�5+      �� 	Összsen:6/   �� 5,      $
��Bold"�6$   $��	10,0,20,0q�6v   ��66   �� *Sum+$ c0��$ hu-HU��6�   5-      5.      J� 5/      $��25(�6   .*�6,   .*�50      �� .+�51      �� $��Készült: ��6$   68   �� 52      ��6$   �� *	Keszult+6?   53      54      J� 55      $ Right=�6   $��20(�62   .*�6@   .*�56      �� $��0q�6!   $	��300��6,   .+�57      �� $	��300��6$   $
��Left=�60   JH........................................................................6�   �� 58      $��Center=�6%   Dolgozó aláírása6T   59      5:      5;      5<      �� 5=      $��1��6   .+�5>      �� $��
Nyomtatás��6   .  (System.Windows.Interactivity.Interaction   Triggers 5?      /  )System.Windows.Interactivity.EventTrigger  5@         	EventName$ Click��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5A      "	  Caliburn.Micro.ActionMessage	   	  
MethodName$ Print��6,    	  
Parameters. 5B      
  Caliburn.Micro.Parameter
   
  Value 6,   ��  �� ElementName$ Document��5C      5D      5F      5G      5I      5J      