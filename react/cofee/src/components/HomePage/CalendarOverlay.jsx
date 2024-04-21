import { useState } from "react";
import Calendar from "react-calendar";

const CalendarOverlay = () => {
  const [date, setDate] = useState(new Date());

  const onChange = (newDate) => {
    setDate(newDate);
    // Добавьте здесь любую логику, которая должна выполняться при изменении даты
  };

  return (
    <div className="calendar-overlay">
      <Calendar onChange={onChange} value={date} />
    </div>
  );
};

export default CalendarOverlay;
