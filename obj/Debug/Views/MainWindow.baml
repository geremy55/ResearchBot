   M S B A M L   `   `   `  ����F  BResearchBot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:ResearchBotResearchBot  5   	   "    ResearchBot.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:ResearchBot     5   	   -   5        $	��600��5   	   $	��600��6     � WindowStyle$
  None=�6(    � 
ResizeMode$ CanMinimize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ ResearchBot��6.   ���#191919$	��500��5      $	��500��6*   ��5      �� 5   
    �� 
TargetType" �6   .R�5      �� $��	newBorder��6   ���#353535
�������$��2q�5   ,   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   �� 5      �� 5      $
��Auto �6(   .+�5      �� #��z 6    $��18(�6?   
�������$��10,5,0,0q�5   /   $
��Left=�6A   �� 5       ��Name$ 
HideButton��6   -   5        $��-��5   1      
ButtonMenu#��[  5       � ToolTip$ Свернуть окно��6C   $��Right=�5      $��0,3,35,0q�69   �� 5      $ CloseButton��6   -   5        $��X��5   2   #��[  5       $ Закрыть окно��6A   $��Right=�5!      $��0,3,5,0q�69   �� 5#      $��1��6   ._�5$      �� .u�5%      �� 5&      5'      �� 5)      $��2��6!   $��Right=�6.   $��Bottom=�6J   $y�	Collapsed=�5*      ��.  64   5+      5,      5-      .��5/      �   MainWndStyle#��[ 6   $��3q�61    � ColumnDefinitions 50   
   �� 51       53   
   �� 54      �� 55      �� 56      .+�58   
   �� .+�59      �� 	 �� Orientation$	 
Horizontal=�6   $��Stretch=�62   .+�5:      �� $��10,0,0,0q�6   $	 
Horizontal=�6/   $��Center=�6H   $��Stretch=�6c   .+�5;      �� 
�������$��10,0,0,0q�6/   .��6A   Аккаунт6J   �� 5<      
�������$��10,0,0,0q�6/   6C   5=      �� 5>      $	 
Horizontal=�6   $��Stretch=�66   .+�5?      �� $	��120��6   5@      5A      5B      5D      �� 5E   
   $��1��6   $	 Vertical=�6"   .+�5F      �� $	 
Horizontal=�6   $��Right=�62   $��5q�6N   .+�5G      �� $��Кол-во ставок��6   
�������60   �� 5H      -   5        
 ��Name$
 count��5H      $��	10,0,10,0q�6*   $��50��6=   $��Center=�6�     TextBoxStyle#��[ 5I      ��5H   H   ��  �� Path$ ViewObject.BetCount� �� Mode$ OneWay=� �� NotifyOnSourceUpdated . 5I      5J      �� 5K      $	 
Horizontal=�6   $��Right=�62   $��5q�6N   .+�5L      �� $��Баланс��6   
�������6)   �� 5M      -   5        $
 Balance��5M      $��	10,0,10,0q�6,   $	��120��6?   $��Center=�6�   #��[ 5N      ��5M   K   �� $ ViewObject.Balance�$ OneWay=� . 5N      5O      �� 5P      $	 
Horizontal=�6   $��Right=�62   $��5q�6N   .+�5Q      �� $��Потерь подряд��6   
�������60   �� 5R      -   5        $
 Negative��5R      $��	10,0,10,0q�6-   $��40��6@   $��Center=�6�   #��[ 5S      ��5R   K   �� $ ViewObject.NegativeBets�$ OneWay=� . 5S      5T      �� 5U      -   5        $ start��5U      $��	20,0,20,0q�6�   $��Stretch=�5V        ButtonTemplate#��[ 6�   ��5U   $   �� $ ViewObject.ButtonText�$ OneWay=� . ��6|   �� $ StartCommand�{�5V   3   �� $ ViewObject.BetsOn�$ OneWay=� �� NotifyOnTargetUpdated . 6�   5W      5Y      5Z      