function Timer()
{
    this.start_time = "2:00";
    this.target_id = "#auction";
}
Countdown.prototype.init()
{
    this.reset();
    setInterval(this.name + '.tick()', 1000);
}
Countdown.prototype.reset()
{
    time = this.start_time.split(":");
    this.minutes = parseInt(time_ary[0]);
    this.seconds=parseInt(time_ary[1]);
    this.update_target();
}
Countdown.prototype.tick()
{
    if(this.seconds>0||this.minutes>0)
    {
        this.seconds--
        if(this.seconds==0)
        {
            this.minutes = this.minutes-1;
            this.seconds = 59
        }
    }
    this.update_target()
    {
        Countdown.prototype.update_target = function()
        {
            seconds = this.seconds;
            if(seconds<10) seconds = "0" + seconds;
            $(this.target_id).val(this.minutes+":"+seconds)
        }
    }
}