   M S B A M L   `   `   `  ����E  AMastermind, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Mastermind
Mastermind  5   	       Mastermind.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Mastermind     5   	     � Title$  Master Mind��5   	   $	��700��6   $	��800��6-   .��5	      � $��0,0,0,7q�6    � RowDefinitions 5
   
   �� 5      $��50��6   �� 5      $��50 �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $	��300 �6   .+�5   
   �� -   5         ��Name$ TestResultlb��5      $��0��6&   $��1��63   $��Success��6D   $��24(�6V   $y�	Collapsed=�6d   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �  5      �� 5      $	��355 �6'   �� 5      $	��100 �6'   .+�5      �� -   5         ��Name$ CodeToBreakStck��5      $��0��66   �� 5      -   5         ��Name$ ShowCode��5      $��1��6+   $y�	Collapsed=�6;   $	��110��6g      ShowCodeBreakerButton#��[  6s   6�   �� 5      -   5        $ HideCode��5      $��1��6+   $y�	Collapsed=�6<   $	��110��6h     HideBreakerButton#��[ 6t   6�   5      5       �� 5!   
   -   5        $ CodePegsLinesStck��5!      $��2��60   $��0��6=   $��3��6M   �� 5"   
   -   5        $ Information��5"      $��2��6*   $��1��67   $
��Left=�6G   $y�	Collapsed=�6b   .+�5#      �  5$      �� 5%      $��20 �6'   �� 5&      $��35 �6'   �� 5'      $	��190 �6'    5)      �� 5*      �� 5+      �� 5,      .+�5.      A� $��1��6   $��0��6*   
��� ���
���   �$��20��6T   $��20��6_   6m   �� 5/      $��2��6   $��0��6(   $$��Right color and right position��65   A� 50      $��1��6   $��1��6*   
�������
���   �$��20��6T   $��20��6_   �� 51      $��2��6   $��1��6(   $$��Right color and wrong position��65   A� 52      $��1��6   $��2��6*   
�������
���   �$��20��6V   $��20��6a   6o   �� 53      $��2��6   $��2��6(   $$��Right color and wrong position��65   54      55      �� 56   
   -   5        $ TryagainBtn��56      $��1��6&   $��3��66     TryAgainButton#��[ 6C   $	��100��6o   $y�	Collapsed=�6�   6�   �� 57   
   -   5        $ PlayBtn��57      $��2��6#   $��2��60     
PlayButton#��[ 6Z   59      5:      